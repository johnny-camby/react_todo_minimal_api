import { useFetchTodos, useUpdateTodo } from "../hooks/TodoHooks";
import ApiStatus from "../ApiStatus";
import TodoAdd from "./TodoAdd";
import { Todo } from "../types/todo";
import TodoItem from "./TodoItem";

const TodoList = () => {
    const { data, status, isSuccess } = useFetchTodos();
    const updateTodoMutation = useUpdateTodo();

    if (!isSuccess) return <ApiStatus status={status}></ApiStatus>;

    const completeTodo = async (id: number) => {
        // const todo = data.find(item => item.id === id);

        // if (todo?.id === id) {
        //     todo.isDone = !todo.isDone;
        //     updateTodoMutation.mutate(todo);
        // }
        const todosToUpdate = data.map(todo => (todo.id === id ? { ...todo, isDone: true } : todo));
        let updatedTodo = todosToUpdate.find(todo => todo.id === id) as Todo;
        updateTodoMutation.mutate(updatedTodo);
    }

    return (
        <div>
            <TodoAdd />
            <hr />
            <ul className="list-group">
                {data && data.map((todo: Todo) => (
                    <TodoItem
                        key={todo.id}
                        todo={todo}
                        completeTodo={completeTodo}
                    />
                ))}
            </ul>
        </div>
    );
};

export default TodoList;
