import { useDeleteTodo } from "../hooks/TodoHooks";
import dateformat from "dateformat";
import { Todo } from "../types/todo";
import { RiCloseCircleLine } from "react-icons/ri"
import { BiCheckCircle } from "react-icons/bi"
import overdue from "../types/overdue";

type Args = {
    todo: Todo;
    completeTodo: (id: number) => void;
};

const TodoItem = ({ todo, completeTodo }: Args) => {

    const todoClass = `list-group-item list-group-item-${overdue(todo) ? "danger" : "info"}`;
    const deleteTodoMutation = useDeleteTodo();

    return (
        <li className={todoClass}>
            <div className="todo-item">
                <span className={`todo-item-title${todo.isDone ? " completed-todo" : ""}`}>
                    <i className={overdue(todo) ? "bi bi-exclamation-triangle" : ""} />
                    <span>{`${todo.text}`}</span>
                    <span style={{ float: 'right', paddingLeft: '100px', paddingRight: '100px' }}>{`${dateformat(new Date(todo.deadLine), "dd-mmm-yyyy")}`}</span>
                </span>
                {!todo.isDone && (
                    <BiCheckCircle onClick={() => completeTodo(todo.id)} />
                )} &nbsp;|&nbsp;
                <RiCloseCircleLine style={{ marginRight: 5 }} onClick={() => deleteTodoMutation.mutate(todo)} />
            </div>
        </li>
    );
};

export default TodoItem;