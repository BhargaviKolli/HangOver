using HangOver1.DTO;
using HangOver1.Models;

namespace HangOver1.Repositories
{
	public interface IPosts
	{
	
		IEnumerable<Post>GetAllPosts();

	    public Post GetPostByUserId(int UserId);

		public Post GetPostById(int PostId);

		public void DeleteByPostId(int PostId);

		public PostDTO CreatePost(PostDTO postdto);



	}
}
