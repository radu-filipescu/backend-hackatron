using backend_hackatron.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_hackatron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<NodeDTO> GetNodes()
        {
            NodeDTO node1 = new NodeDTO();

            node1.Id = "12321awrata131142pa";
            node1.Name = "my first node";
            node1.Password = "masina majora";
            node1.IsMining = false;
            node1.Balance = 500;

            NodeDTO node2 = new NodeDTO();

            node2.Id = "999wrqt1aw5467131";
            node2.Name = "my second node";
            node2.Password = "gagica minora";
            node2.IsMining = true;
            node2.Balance = 1500;

            return new NodeDTO[] { node1, node2 };
        }

        [HttpGet("{id}")]
        public string GetNodeById(string id)
        {
            return "value";
        }

        [HttpPost]
        public NodeDTO CreateNode([FromBody] NodeDTO nodeDto)
        {
            NodeDTO node1 = new NodeDTO();

            node1.Id = "12321awrata131142pa";
            node1.Name = "my first node";
            node1.Password = "masina majora";
            node1.IsMining = false;
            node1.Balance = 500;

            return node1;
        }

        [HttpPut("{id}")]
        public void EditNode(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void DeleteNode(int id)
        {
        }
    }
}
