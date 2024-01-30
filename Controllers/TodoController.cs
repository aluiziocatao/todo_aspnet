using Microsoft.AspNetCore.Mvc;
using TWTodos_ASP.NET.Contexts;
using TWTodos_ASP.NET.Models;

namespace TWTodos_ASP.NET.Controllers;

public class TodoController : Controller {

    private readonly TWTodosContext _context;

    public TodoController(TWTodosContext context) {
        _context = context;
    }

    public IActionResult Index() {
       ViewData["Title"] = "Lista de Tarefas";
       var todos = _context.Todos.ToList();
        return View(todos);
    }

    public IActionResult Create() {
        ViewData["Title"] = "Adicionar Nova Tarefa";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create(Todo todo) {
        todo.CreatedAt = DateTime.Now;
        _context.Todos.Add(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult Edit(int id) {
        var todo = _context.Todos.Find(id);
        ViewData["Title"] = "Editar Tarefa";
        return View("Form", todo);
    }

    [HttpPost]
    public IActionResult Edit(Todo todo) {
        _context.Todos.Update(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id) {
        var todo = _context.Todos.Find(id);
        ViewData["Title"] = "Excluir Tarefa";
        return View(todo);
    }

    [HttpPost]
    public IActionResult Delete(Todo todo) {
        _context.Todos.Remove(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}