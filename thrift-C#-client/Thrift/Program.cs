using com.auth.user;
using com.exception;
using com.service.impl;
using System;
using Thrift.Protocol;
using Thrift.Transport;

namespace Thrift
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TTransport transport = new TSocket("localhost", 9090);
                TProtocol protocol = new TBinaryProtocol(transport);
                LoginService.Client client = new LoginService.Client(protocol);

                transport.Open();
                try
                {
                    if (client.ping())
                    {
                        Console.WriteLine("connected");
                        do
                        {
                            Console.WriteLine("Login");
                            Console.WriteLine("Nhap User Name: ");
                            string UserName = Console.ReadLine();
                            Console.WriteLine("Nhap password: ");
                            string password = Console.ReadLine();
                            UserInfoRequest request = new UserInfoRequest();
                            request.UserName = UserName;
                            request.Password = password;
                            UserInfoRespone response = client.login(request);
                            if (response != null)
                            {
                                Console.WriteLine("Dang nhap thanh cong: " + response.UserName);
                            }else
                            {
                                Console.WriteLine("Dang nhap that bai");
                            }
                            
                        } while (Console.ReadKey().Key != ConsoleKey.Enter);
                      
                    }
                    else
                    {
                        Console.WriteLine("not connect");
                      
                    }
                    Console.ReadKey();
                }
                finally
                {
                    transport.Close();
                }
            }
            catch (TApplicationException x)
            {
                Console.WriteLine(x.StackTrace);
                Console.ReadKey();
            }
            catch (UserAuthException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}
