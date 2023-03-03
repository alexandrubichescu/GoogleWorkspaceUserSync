using AutoMapper;
using GWUserSync.Models;
using GWUserSync.Data;

namespace GWUserSync.Helpers;

public class AppMapper : Profile
{
    public AppMapper()
    {
        CreateMap<User, UserModel>().ReverseMap().ForMember(x=>x.Id,o=>o.Ignore());
    }
}
