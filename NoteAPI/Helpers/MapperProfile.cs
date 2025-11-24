using AutoMapper;
using Entity;

namespace NoteAPI.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<BaseNote, NormalNote>();
        CreateMap<BaseNote, CheckNote>();
    }
}