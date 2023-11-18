using AutoMapper;
using KanbanFlow.API.Models.Domain;
using KanbanFlow.API.Models.DTOs.Comment;
using KanbanFlow.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KanbanFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentsController(ICommentRepository repo, IMapper mapper)
        {
            _commentRepository = repo;
            _mapper = mapper;
        }

        [HttpPost("{taskId:Guid}")]
        [Authorize(Roles = "Manager, Developer")]
        public async Task<IActionResult> AddNewCommentToTask(Guid taskId, [FromBody] CommentAddDto newComment)
        {
            var commentDomain = _mapper.Map<Comment>(newComment);
            commentDomain = await _commentRepository.CreateCommentAsync(taskId, commentDomain);
            var commentDto = _mapper.Map<CommentDto>(commentDomain);
            return Ok(commentDto);
        }

        [HttpDelete("{commentId:Guid}")]
        [Authorize(Roles = "Manager, Developer")]
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            var commentDomain = await _commentRepository.DeleteCommentByIdAsync(commentId);
            if (commentDomain == null)
                return NotFound();

            var commentDto = _mapper.Map<CommentDto>(commentDomain);
            return Ok(commentDto);
        }

        [HttpPut("{commentId:Guid}")]
        [Authorize(Roles = "Manager, Developer")]
        public async Task<IActionResult> UpdateComment(Guid commentId, [FromBody] CommentUpdateDto updatedComment)
        {
            var commentDomain = _mapper.Map<Comment>(updatedComment);
            commentDomain = await _commentRepository.UpdateCommentByIdAsync(commentId, commentDomain);
            if (commentDomain == null)
                return NotFound();

            var commentDto = _mapper.Map<CommentUpdateDto>(commentDomain);
            return Ok(commentDto);
        }
    }
}
