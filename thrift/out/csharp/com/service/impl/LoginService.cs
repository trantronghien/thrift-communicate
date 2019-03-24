/**
 * Autogenerated by Thrift Compiler (0.12.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace com.service.impl
{
  public partial class LoginService {
    public interface ISync : com.service.impl.BaseService.ISync {
      com.auth.user.UserInfoRespone login(com.auth.user.UserInfoRequest user);
    }

    public interface Iface : ISync {
      #if SILVERLIGHT
      IAsyncResult Begin_login(AsyncCallback callback, object state, com.auth.user.UserInfoRequest user);
      com.auth.user.UserInfoRespone End_login(IAsyncResult asyncResult);
      #endif
    }

    public class Client : com.service.impl.BaseService.Client, Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot) : base(iprot, oprot)
      {
      }

      
      #if SILVERLIGHT
      
      public IAsyncResult Begin_login(AsyncCallback callback, object state, com.auth.user.UserInfoRequest user)
      {
        return send_login(callback, state, user);
      }

      public com.auth.user.UserInfoRespone End_login(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_login();
      }

      #endif

      public com.auth.user.UserInfoRespone login(com.auth.user.UserInfoRequest user)
      {
        #if SILVERLIGHT
        var asyncResult = Begin_login(null, null, user);
        return End_login(asyncResult);

        #else
        send_login(user);
        return recv_login();

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_login(AsyncCallback callback, object state, com.auth.user.UserInfoRequest user)
      {
        oprot_.WriteMessageBegin(new TMessage("login", TMessageType.Call, seqid_));
        login_args args = new login_args();
        args.User = user;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        return oprot_.Transport.BeginFlush(callback, state);
      }

      #else

      public void send_login(com.auth.user.UserInfoRequest user)
      {
        oprot_.WriteMessageBegin(new TMessage("login", TMessageType.Call, seqid_));
        login_args args = new login_args();
        args.User = user;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }
      #endif

      public com.auth.user.UserInfoRespone recv_login()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        login_result result = new login_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        if (result.__isset.e) {
          throw result.E;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "login failed: unknown result");
      }

    }
    public class Processor : com.service.impl.BaseService.Processor, TProcessor {
      public Processor(ISync iface) : base(iface)
      {
        iface_ = iface;
        processMap_["login"] = login_Process;
      }

      private ISync iface_;

      public new bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void login_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        login_args args = new login_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        login_result result = new login_result();
        try
        {
          try
          {
            result.Success = iface_.login(args.User);
          }
          catch (com.exception.UserAuthException e)
          {
            result.E = e;
          }
          oprot.WriteMessageBegin(new TMessage("login", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("login", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class login_args : TBase
    {
      private com.auth.user.UserInfoRequest _user;

      public com.auth.user.UserInfoRequest User
      {
        get
        {
          return _user;
        }
        set
        {
          __isset.user = true;
          this._user = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool user;
      }

      public login_args() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              case 1:
                if (field.Type == TType.Struct) {
                  User = new com.auth.user.UserInfoRequest();
                  User.Read(iprot);
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("login_args");
          oprot.WriteStructBegin(struc);
          TField field = new TField();
          if (User != null && __isset.user) {
            field.Name = "user";
            field.Type = TType.Struct;
            field.ID = 1;
            oprot.WriteFieldBegin(field);
            User.Write(oprot);
            oprot.WriteFieldEnd();
          }
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("login_args(");
        bool __first = true;
        if (User != null && __isset.user) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("User: ");
          __sb.Append(User);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class login_result : TBase
    {
      private com.auth.user.UserInfoRespone _success;
      private com.exception.UserAuthException _e;

      public com.auth.user.UserInfoRespone Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }

      public com.exception.UserAuthException E
      {
        get
        {
          return _e;
        }
        set
        {
          __isset.e = true;
          this._e = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
        public bool e;
      }

      public login_result() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              case 0:
                if (field.Type == TType.Struct) {
                  Success = new com.auth.user.UserInfoRespone();
                  Success.Read(iprot);
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              case 1:
                if (field.Type == TType.Struct) {
                  E = new com.exception.UserAuthException();
                  E.Read(iprot);
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("login_result");
          oprot.WriteStructBegin(struc);
          TField field = new TField();

          if (this.__isset.success) {
            if (Success != null) {
              field.Name = "Success";
              field.Type = TType.Struct;
              field.ID = 0;
              oprot.WriteFieldBegin(field);
              Success.Write(oprot);
              oprot.WriteFieldEnd();
            }
          } else if (this.__isset.e) {
            if (E != null) {
              field.Name = "E";
              field.Type = TType.Struct;
              field.ID = 1;
              oprot.WriteFieldBegin(field);
              E.Write(oprot);
              oprot.WriteFieldEnd();
            }
          }
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("login_result(");
        bool __first = true;
        if (Success != null && __isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success== null ? "<null>" : Success.ToString());
        }
        if (E != null && __isset.e) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("E: ");
          __sb.Append(E);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }

  }
}
