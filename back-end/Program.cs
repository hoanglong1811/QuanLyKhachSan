using back_end.Data;
using Microsoft.EntityFrameworkCore;
using back_end.Services;
using back_end.ViewModels;
using Microsoft.AspNetCore.Builder;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataQlks114Nhom3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

builder.Services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();
builder.Services.AddScoped<IHoaDonRepository, HoaDonRepository>();
builder.Services.AddScoped<ILoaiPhongRepository, LoaiPhongRepository>();
builder.Services.AddScoped<IPhanQuyenRepository, PhanQuyenRepository>();
builder.Services.AddScoped<IPhieuBaoTriRepository, PhieuBaoTriRepository>();
builder.Services.AddScoped<IPhongRepository, PhongRepository>();
builder.Services.AddScoped<IThietBiRepository, ThietBiRepository>();
builder.Services.AddScoped<IVaiTroRepository, VaiTroRepository>();
builder.Services.AddScoped<IPhieuBaoTriRepository, PhieuBaoTriRepository>();
builder.Services.AddScoped<IChiTietBaoTriRepository, ChiTietBaoTriRepository>();
builder.Services.AddScoped<IChiTietDatPhongRepository, ChiTietDatPhongRepository>();
builder.Services.AddScoped<IChiTietDichVuRepository, ChiTietDichVuRepository>();





builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy => policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowVueApp");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
