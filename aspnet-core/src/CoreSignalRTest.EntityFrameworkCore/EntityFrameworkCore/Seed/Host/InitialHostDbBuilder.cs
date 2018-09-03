namespace CoreSignalRTest.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly CoreSignalRTestDbContext _context;

        public InitialHostDbBuilder(CoreSignalRTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
