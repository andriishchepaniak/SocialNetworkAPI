using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<PostDTO> Create(PostDTO post)
        {
            var p = mapper.Map<Post>(post);
            return mapper.Map<PostDTO>(await unitOfWork.PostRepository.Create(p));
        }

        public async Task<PostDTO> Delete(int id)
        {
            return mapper.Map<PostDTO>(await unitOfWork.PostRepository.Delete(id));
        }

        public async Task<IEnumerable<PostDTO>> GetAll()
        {
            return mapper.Map<IEnumerable<PostDTO>>(await unitOfWork.PostRepository.GetAll());
        }

        public async Task<PostDTO> GetById(int id)
        {
            return mapper.Map<PostDTO>(await unitOfWork.PostRepository.GetById(id));
        }

        public async Task<PostDTO> Update(PostDTO post)
        {
            var p = mapper.Map<Post>(post);
            return mapper.Map<PostDTO>(await unitOfWork.PostRepository.Update(p));
        }
    }
}
