﻿using Forum3.Contexts;
using System;
using System.Threading.Tasks;

namespace Forum3.Services.Controller {
	using ViewModels = Models.ViewModels.Profile;

	public class ProfileService {
		ApplicationDbContext DbContext { get; }
		UserContext UserContext { get; }

		public ProfileService(
			ApplicationDbContext dbContext,
			UserContext userContext
		) {
			DbContext = dbContext;
			UserContext = userContext;
		}

		public async Task<ViewModels.DetailsPage> DetailsPage(string id) {
			if (string.IsNullOrEmpty(id))
				id = UserContext.ApplicationUser.Id;

			var userRecord = await DbContext.Users.FindAsync(id);

			if (userRecord is null)
				throw new Exception($"No record found with the id {id}");

			// TODO check access rights i.e trim email

			var viewModel = new ViewModels.DetailsPage {
				Id = userRecord.Email,
				DisplayName = userRecord.DisplayName,
				Email = userRecord.Email,
			};

			return viewModel;
		}
	}
}