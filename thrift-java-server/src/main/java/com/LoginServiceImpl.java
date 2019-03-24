package com;

import com.auth.user.UserInfoRequest;
import com.auth.user.UserInfoRespone;
import com.exception.UserAuthException;
import com.service.impl.LoginService;
import com.service.impl.UserInfo;
import org.apache.thrift.TException;

import java.util.ArrayList;

public class LoginServiceImpl implements LoginService.Iface {
    public ArrayList<UserInfo> dbUser = new ArrayList<>();

    public LoginServiceImpl() {
        dbUser.add(new UserInfo("hientran", "123456"));
        dbUser.add(new UserInfo("test1", "123456"));
        dbUser.add(new UserInfo("test2", "123456"));
        dbUser.add(new UserInfo("test3", "123456"));
    }

    @Override
    public UserInfoRespone login(UserInfoRequest user) throws UserAuthException, TException {
        UserAuthException exception = new UserAuthException();
        if (user != null) {
            UserInfoRespone response = new UserInfoRespone();
            for (UserInfo item : dbUser) {
                if (compareString(item.UserName, user.userName)) {
                    if (compareString(item.password, user.password)) {

                        response.userName = item.UserName;
                        response.id = 1;
                        response.permission = 0;
                        return response;
                    } else {
                        exception.message = "password wrong";
                        exception.code = 1;
                        throw exception;
                    }
                } else {
                    exception.message = "Account does not exist";
                    exception.code = 2;
                    throw exception;
                }
            }
            return response;
        } else {
            exception.message = "Not found info login";
            exception.code = 3;
            throw exception;
        }
    }

    @Override
    public boolean ping() throws TException {
        System.out.println("Client Connecting");
        return true;
    }

    private boolean compareString(String s1, String s2) throws UserAuthException {
        if (s1 != null && !s1.isEmpty() && s2 != null && !s2.isEmpty()) {
            return s1.equalsIgnoreCase(s2);
        } else {
            throw new UserAuthException(1, "UserName and Password empty");
        }
    }
}
