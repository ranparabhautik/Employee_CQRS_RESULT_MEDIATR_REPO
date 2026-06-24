global using MediatR;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;

global using Employee_Result_CQRS_MediatR_Repo.Result;
global using Employee_Result_CQRS_MediatR_Repo.Models.Entities;
global using Employee_Result_CQRS_MediatR_Repo.Models.DTOs;


global using Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Command;
global using Employee_Result_CQRS_MediatR_Repo.Repository.CommandRepository.Interface;
global using Employee_Result_CQRS_MediatR_Repo.Repository.QueryRepository.Interface;