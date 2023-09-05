using HangOver1.DTO;
using HangOver1.Models;

namespace HangOver1.Repositories
{
	public interface IComments
	{

		List<Comment> GetAllComments();
		Comment GetCommentsByPostId(int PostId);

		public CommentsDTO PostComment(CommentsDTO commentsdto);

		public void DeleteByPostId(int PostId);



	}
}
