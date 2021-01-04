using Graphql.Net.Entidades;
using Graphql.Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graphql.Net.Service
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService(AuthorRepository
                authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }
        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetAuthorById(id);
        }
        public List<BlogPost> GetPostsByAuthor(int id)
        {
            return _authorRepository.GetPostsByAuthor(id);
        }
    }
}
