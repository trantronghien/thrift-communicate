
include "user_info_request.thrift"
include "user_info_response.thrift"
include "user_auth_exception.thrift"
include "base_service.thrift"

namespace java com.service.impl
namespace csharp com.service.impl

typedef user_info_request.UserInfoRequest UserInfoRequest
typedef user_auth_exception.UserAuthException UserAuthException

service LoginService extends base_service.BaseService {
    user_info_response.UserInfoRespone login(1:UserInfoRequest user) throws (1:UserAuthException e)
}