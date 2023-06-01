import axios, { AxiosError, AxiosResponse } from "axios";
import { useMutation, useQuery, useQueryClient } from "react-query";
import Problem from "../types/Problem";
import { Todo } from "../types/todo";
import Config from "../Config";

const useAddTodo = () => {
    const queryClient = useQueryClient();
    return useMutation<AxiosResponse, AxiosError<Problem>, Todo>(
        (t) => axios.post(`${Config.baseApiUrl}/todos`, t),
        {
            onSuccess: () => {
                queryClient.invalidateQueries("todos");
            }
        }
    );
};

const useFetchTodos = () => {
    return useQuery<Todo[], AxiosError>("todos", () =>
        axios.get(`${Config.baseApiUrl}/todos`)
            .then((resp) => resp.data)
    );
};

const useFetchTodo = (id: number) => {
    return useQuery<Todo, AxiosError>(["todo", id], () =>
        axios.get(`${Config.baseApiUrl}/todo/${id}`)
            .then((resp) => resp.data)
    );
}

const useUpdateTodo = () => {
    const queryClient = useQueryClient();
    return useMutation<AxiosResponse, AxiosError<Problem>, Todo>(
        (t) => axios.put(`${Config.baseApiUrl}/todos`, t),
        {
            onSuccess: (_, todo) => {
                queryClient.invalidateQueries("todos");
            },
        }
    );
};

const useDeleteTodo = () => {
    const queryClient = useQueryClient();
    return useMutation<AxiosResponse, AxiosError, Todo>(
        (t) => axios.delete(`${Config.baseApiUrl}/todos/${t.id}`),
        {
            onSuccess: () => {
                queryClient.invalidateQueries("todos");
            }
        }
    );
}

export {
    useAddTodo,
    useFetchTodos,
    useFetchTodo,
    useUpdateTodo,
    useDeleteTodo
};