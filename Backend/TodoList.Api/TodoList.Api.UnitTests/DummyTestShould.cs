using Moq;
using System;
using System.Collections.Generic;
using TodoList.Api.Models;
using TodoList.Api.RepositoryInterfaces;
using TodoList.Api.Services;
using Xunit;

namespace TodoList.Api.UnitTests
{
    public class DummyTestShould
    {
        private Mock<ITodoItemRepository> _todoItemRepository;

        public DummyTestShould()
        {
            _todoItemRepository = new Mock<ITodoItemRepository>();
        }

        [Fact]
        private async void CheckInsertItem()
        {
            // Arrange
            var testItem = GetTestTodoItem(3);

            _todoItemRepository.Setup(repo => repo.InsertTodoItem(It.IsAny<TodoItem>()));
            var todoItemService = new TodoItemService(_todoItemRepository.Object);

            // Act
            var result = await todoItemService.InsertTodoItem(testItem);

            Assert.True(result.Success);
        }

        [Fact]
        private async void CheckUpdateItem()
        {
            // Arrange
            var testItem = GetTestTodoItem(1);
            testItem.Description = "Mock description";

            _todoItemRepository.Setup(repo => repo.GetTodoItemByID(testItem.Id)).ReturnsAsync(testItem);
            var todoItemService = new TodoItemService(_todoItemRepository.Object);

            // Act
            var result = await todoItemService.UpdateTodoItem(testItem);

            Assert.True(result.Success);
        }

        [Fact]
        private async void ShouldReturnItem()
        {
            // Arrange
            var testItem = GetTestTodoItem(1);

            _todoItemRepository.Setup(repo => repo.GetTodoItemByID(testItem.Id)).ReturnsAsync(testItem);
            var todoItemService = new TodoItemService(_todoItemRepository.Object);

            // Act
            var result = await todoItemService.GetTodoItemByID(testItem.Id);

            Assert.Equal(typeof(TodoItemViewModel), result.GetType());
        }

        [Fact]
        private async void ShouldReturnItemList()
        {
            // Arrange
            _todoItemRepository.Setup(repo => repo.GetTodoItemList()).ReturnsAsync(GetTestTodoItemList());

            var todoItemService = new TodoItemService(_todoItemRepository.Object);

            // Act
            var result = await todoItemService.GetTodoItemList();

            Assert.Equal(typeof(List<TodoItemViewModel>), result.GetType());
        }

        private static TodoItem GetTestTodoItem(int number)
        {
            return new TodoItem()
            {
                Id = Guid.NewGuid(),
                Description = "Item " + number.ToString(),
                IsCompleted = true
            };
        }

        private static List<TodoItem> GetTestTodoItemList()
        {
            var itemList = new List<TodoItem>
            {
                GetTestTodoItem(1),
                GetTestTodoItem(2)
            };

            return itemList;
        }
    }
}
