﻿using AutoMapper;
using Domain.Contracts;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Services.Abstractions;
using Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IProductService> _proudctService;
		private readonly Lazy<IBasketService> _basketService;
		private readonly Lazy<IAthenticationService> _athenticationService;
        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IBasketRepository basketRepository, UserManager<User> userManager, IOptions<Jwtoptions> options, IConfiguration configuration)
        {
            _proudctService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
            _basketService = new Lazy<IBasketService>(() => new BasketService(basketRepository, mapper));
			_athenticationService = new Lazy<IAthenticationService>(() => new AthenticationService(userManager, configuration, options));	
        }
        public IProductService ProductService => _proudctService.Value;

		public IBasketService BasketService => _basketService.Value;

		public IAthenticationService AthenticationService => _athenticationService.Value;
	}
}
