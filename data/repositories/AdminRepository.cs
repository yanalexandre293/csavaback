using Microsoft.EntityFrameworkCore;

public class AdminRepository
{
    private readonly AppDbContext _dbContext;

    public AdminRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarAdmin(Admin admin)
    {
        await _dbContext.Admins.AddAsync(admin);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Admin>> BuscarTodosAdmins()
    {
        return await _dbContext.Admins.ToListAsync();
    }

    public async Task<Admin> BuscarAdmin(int id)
    {
        return await _dbContext.Admins.FirstOrDefaultAsync(admin => admin.Id == id);
    }

    public async Task EditarAdmin(Admin admin)
    {
        var adm = await _dbContext.Admins.FirstOrDefaultAsync(adm => adm.Id == admin.Id);
        adm.Nome = admin.Nome;
        adm.Email = admin.Email;
        adm.Senha = admin.Senha;
        adm.TipoUsuario = admin.TipoUsuario;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoverAdmin(int id)
    {
        var admin = await _dbContext.Admins.FirstOrDefaultAsync(admin => admin.Id == id);
        _dbContext.Remove(admin);
        await _dbContext.SaveChangesAsync();
    }
}