using AutoMapper;
using TodoList.Repositories;

namespace TodoList.Business;

public class TodoItemService(TodoItemRepository todoItemRepository, IMapper mapper)
{
	#region Variables

	private readonly TodoItemRepository _TodoItemRepository = todoItemRepository;
    private readonly IMapper _Mapper = mapper;

    #endregion

    #region Methods

    #endregion
}