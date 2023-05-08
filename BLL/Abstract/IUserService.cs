﻿using DAL.Utility;
using DTO.Responses;
using DTO.User;

namespace BLL.Abstract;

public interface IUserService
{
    Task<IDataResult<List<UserToListDto>>> GetAsync();

    Task<IDataResult<PaginatedList<UserToListDto>>> GetAsPaginatedListAsync();

    Task<IDataResult<UserToListDto>> GetAsync(int id);

    Task<IResult> AddAsync(UserToAddDto dto);

    Task<IResult> UpdateAsync(int id, UserToUpdateDto dto);

    Task<IResult> SoftDeleteAsync(int id);
    Task<IResult> AddProfileAsync(int userId, int? fileId);
}