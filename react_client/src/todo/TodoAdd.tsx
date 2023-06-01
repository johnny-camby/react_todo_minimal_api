import ValidationSummary from "../ValidationSummary";
import { useAddTodo } from "../hooks/TodoHooks";
import { Todo } from "../types/todo";
import TodoForm from "./TodoForm";

const TodoAdd = () => {
    const addTodoMutation = useAddTodo();

    const todo: Todo = {
        id: 0,
        text: "",
        deadLine: "",
        isDone: false
    };

    return (
        <>
            {
                addTodoMutation.isError && (<ValidationSummary error={addTodoMutation.error} />)
            }
            <TodoForm todo={todo} submitted={(todo) => addTodoMutation.mutate(todo)} />
        </>
    );
};

export default TodoAdd;