﻿using Forum3.Annotations;
using Forum3.Models.InputModels;
using Forum3.Services.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum3.Controllers {
	public class Smileys : ForumController {
		SmileyService SmileyService { get; }

		public Smileys(
			SmileyService smileyService
		) {
			SmileyService = smileyService;
		}

		public async Task<IActionResult> Index() {
			var viewModel = await SmileyService.IndexPage();
			return View(viewModel);
		}

		public IActionResult Create() {
			var viewModel = SmileyService.CreatePage();
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[PreventRapidRequests]
		public async Task<IActionResult> Create(CreateSmileyInput input) {
			if (ModelState.IsValid) {
				var serviceResponse = await SmileyService.Create(input);
				ProcessServiceResponse(serviceResponse);

				if (serviceResponse.Success)
					return RedirectFromService();
			}

			var viewModel = SmileyService.CreatePage(input);
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[PreventRapidRequests]
		public async Task<IActionResult> Edit(EditSmileysInput input) {
			if (ModelState.IsValid) {
				var serviceResponse = await SmileyService.Edit(input);
				ProcessServiceResponse(serviceResponse);
			}

			return RedirectFromService();
		}

		public async Task<IActionResult> Delete(int id) {
			var serviceResponse = await SmileyService.Delete(id);
			ProcessServiceResponse(serviceResponse);

			return RedirectFromService();
		}
	}
}