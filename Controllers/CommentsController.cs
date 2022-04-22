#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsCommentAPIService.Data;
using NewsCommentAPIService.Models;

namespace NewsCommentAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly NewsCommentAPIServiceContext _context;

        public CommentsController(NewsCommentAPIServiceContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComment(int reportId, Guid? createdBy, bool desc = true)
        {
		var guidIsEmpty = (createdBy == null || createdBy.Value == Guid.Empty);
		
		// Baseline for select for the reports	  		
		var comments = from c in _context.Comment select c;	  		
		
		comments = comments.Where(x => x.ReportId == reportId);
		
       	    	if (!guidIsEmpty)
       	    	{
       	    		comments = comments.Where(x => x.CreatedBy == createdBy);
		}

		if (desc) 
		{
			comments = comments.OrderByDescending(s => s.UpdatedDate);
		}
		
		return await comments.ToListAsync();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comment.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

	    var comment_orig = await _context.Comment.FindAsync(id);

            comment_orig.UpdatedDate = DateTime.Now;
            comment_orig.CommentText = comment.CommentText;

            _context.Entry(comment_orig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            //comment.CreatedBy = new Guid();
            comment.UpdatedDate = DateTime.Now;
            comment.CreatedDate = DateTime.Now;
            //comment.ReportId = comment.Id;

            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }


       // DELETE: api/Comments/Report/5
        [HttpDelete, Route("Reports/{id}")]
        public async Task<IActionResult> DeleteComments(int id)
        {
        
 		var match = await _context.Comment.Where(x => x.ReportId == id).ToListAsync();
   		if(match.Any())
   		{
   			foreach (var comm in match)
   			{
   		      		_context.Comment.Remove(comm);
   		      	}
            	      
   		}        
   		await _context.SaveChangesAsync();

            if (match == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }
    }
}
