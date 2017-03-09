namespace ToDoApp.Api.Mappings
{
    public static class AutoMappingConfiguration
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize((cfg) =>
            {
                cfg.AddProfiles(IoC.AutoMapperConfiguration.GetAutoMapperProfiles());
            });
        }
    }
}
