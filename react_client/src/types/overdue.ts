import { Todo } from "./todo";

 export default (todo:Todo) => !todo.isDone && Date.parse(todo.deadLine) < new Date().getTime();