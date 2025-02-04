﻿using BornToMove.Business;
using BornToMove.DAL;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MoveContext>(); // Dit zorgt dat MoveContext automatisch wordt geïnjecteerd daar waar een constructor hem gebruikt
builder.Services.TryAddScoped<MoveCrud>(); // Dit zorgt dat MoveCrud automatisch wordt geïnjecteerd daar waar een constructor hem gebruikt
builder.Services.TryAddScoped<MoveRatingCrud>();
builder.Services.TryAddScoped<BuMove>(); // Dit zorgt dat BuMove automatisch wordt geïnjecteerd daar waar een constructor hem gebruikt

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddJsonOptions(options =>
   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
