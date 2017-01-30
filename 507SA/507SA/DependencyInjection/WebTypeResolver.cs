﻿using DAL.EF;
using DAL.Repository.ImageRepository;
using DAL.Repository.SubjectRepository;
using DAL.Repository.UserRepository;
using DAL.UnitOfWork;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Data.Entity;
using System.Web.Mvc;

namespace _507SA.DependencyInjection
{
	public class WebTypeResolver: IWebTypeResolver
	{
		public void RegisterType(IUnityContainer container)
		{
			container.RegisterType<DbContext, _507SAContext>(new InjectionConstructor());
			container.RegisterType<IUnitOfWork, UnitOfWork>();
			container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
			container.RegisterType<ISubjectRepository, SubjectRepository>(new HierarchicalLifetimeManager());
			container.RegisterType<IImageRepository, ImageRepository>(new HierarchicalLifetimeManager());
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}