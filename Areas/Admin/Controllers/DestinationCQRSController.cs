﻿using Microsoft.AspNetCore.Mvc;
using Traversal.CQRS.Commands.DestinationCommands;
using Traversal.CQRS.Handlers.DestinationHandlers;
using Traversal.CQRS.Queries.DestinationQueries;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _handler;
        private readonly GetDestinationByIDQueryHandler _handlerID;
        private readonly CreateDestinationCommandHandler _createHandler;
        private readonly RemoveDestinationCommandHandler _removeHandler;
        private readonly UpdateDestinationCommandHandler _updateHandler;
        public DestinationCQRSController(GetAllDestinationQueryHandler handler, GetDestinationByIDQueryHandler handlerID, CreateDestinationCommandHandler createHandler, RemoveDestinationCommandHandler removeHandler, UpdateDestinationCommandHandler updateHandler)
        {
            _handler = handler;
            _handlerID = handlerID;
            _createHandler = createHandler;
            _removeHandler = removeHandler;
            _updateHandler = updateHandler;
        }

        public IActionResult Index()
        {
            var values = _handler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var values = _handlerID.Handle(new GetDestinationByIDQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            _removeHandler.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }
            
    }
}
