using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PropertyManager.Api.Domain;
using PropertyManager.Api.Infrastructure;
using PropertyManager.Api.Models;
using AutoMapper;

namespace PropertyManager.Api.Controllers
{
    [Authorize]
    public class WorkOrdersController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/WorkOrders
        public IEnumerable<WorkOrderModel> GetWorkOrders()
        {
            return Mapper.Map<IEnumerable<WorkOrderModel>>(
                db.WorkOrders.Where(wo => wo.User.UserName == User.Identity.Name
                ));
        }

        // GET: api/WorkOrders/5
        [ResponseType(typeof(WorkOrderModel))]
        public IHttpActionResult GetWorkOrder(int id)
        {
            WorkOrder workOrder = db.WorkOrders.FirstOrDefault(wo => wo.User.UserName == User.Identity.Name && wo.WorkOrderId == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<WorkOrderModel>(workOrder));
        }

        // PUT: api/WorkOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkOrder(int id, WorkOrderModel modelWorkOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelWorkOrder.WorkOrderId)
            {
                return BadRequest();
            }

            WorkOrder dbWorkOrder = db.WorkOrders.FirstOrDefault(wo => wo.User.UserName == User.Identity.Name && wo.WorkOrderId == id);
            if (dbWorkOrder == null)
            {
                return BadRequest();
            }
            dbWorkOrder.Update(modelWorkOrder);
            db.Entry(modelWorkOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WorkOrders
        [ResponseType(typeof(WorkOrder))]
        public IHttpActionResult PostWorkOrder(WorkOrderModel workOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbWorkOrder = new WorkOrder();
            dbWorkOrder.User = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            dbWorkOrder.Update(workOrder);

            db.WorkOrders.Add(dbWorkOrder);
            db.SaveChanges();

            workOrder.WorkOrderId = dbWorkOrder.WorkOrderId;

            return CreatedAtRoute("DefaultApi", new { id = workOrder.WorkOrderId }, workOrder);
        }

        // DELETE: api/WorkOrders/5
        [ResponseType(typeof(WorkOrder))]
        public IHttpActionResult DeleteWorkOrder(int id)
        {
            WorkOrder workOrder = db.WorkOrders.FirstOrDefault(wo => wo.Property.UserId == User.Identity.Name);
            if (workOrder == null)
            {
                return NotFound();
            }

            db.WorkOrders.Remove(workOrder);
            db.SaveChanges();

            return Ok(workOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkOrderExists(int id)
        {
            return db.WorkOrders.Count(e => e.WorkOrderId == id) > 0;
        }
    }
}