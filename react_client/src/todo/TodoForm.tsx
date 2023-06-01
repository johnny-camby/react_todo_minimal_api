import React, { useState } from "react";
import { Todo } from "../types/todo";

type Args = {
    todo: Todo;
    submitted: (todo: Todo) => void;
};

const TodoForm = ({ todo, submitted }: Args) => {
    const [todoState, setTodoState] = useState({ ...todo });
    const [taskError, setTaskError] = useState("")

    const onSubmit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
        e.preventDefault();

        let taskValid = false;
        if (todoState.text.length < 10) {
            setTaskError("A task must be longer than 10 characters");
        }
        else {
            setTaskError("");
            taskValid = true;
            submitted(todoState);
        }
    };

    const onDateFocus = (e: any) => (e.target.type = "datetime-local");

    return (
        <form className="mt-2" >
            <div className="row">
                <div className="col-5">
                    <input type="text"
                        id="task"
                        minLength={10}
                        className="form-control"
                        placeholder="Enter a task"
                        value={todoState.text}
                        onChange={(e) => setTodoState({ ...todoState, text: e.target.value })}
                        required
                    />
                    {taskError.length > 0 && <span className="mb-5 error-span">{taskError}</span>}
                </div>
                <div className="col-5">
                    <input
                        type="text"
                        className="form-control"
                        placeholder="Enter a deadline "
                        onFocus={onDateFocus}
                        value={todoState.deadLine}
                        onChange={(e) => setTodoState({ ...todoState, deadLine: e.target.value })} />
                </div>
                <div className="col-2">
                    <button data-toggle="tooltip" data-placement="top" title="Tooltip on top" className="btn btn-outline-secondary" disabled={!todoState.text || !todoState.deadLine} onClick={onSubmit}>Submit</button>
                </div>
            </div>
        </form>
    );
};

export default TodoForm;