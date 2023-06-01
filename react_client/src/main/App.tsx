import './App.css';
import Header from './Header';
import TodoList from '../todo/TodoList';


function App() {

  return (
    <div className="container todo-container">
      <Header subtitle="React ToDo demo App" />
      <div className="todo-list">
        <TodoList />
      </div>
    </div>
  );
}

export default App;
