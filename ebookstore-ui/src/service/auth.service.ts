import { CreateUserModel, LoginModel } from "../models/AuthModel";
import UserModel from "../models/UserModel";
import request from "./request";

class AuthService {
    ENDPOINT = 'api/User';
    // ENDPOINT = '';

    public async login(data: LoginModel): Promise<UserModel> {
        const url = `${this.ENDPOINT}/Login`;
        // const url = `/Login`;
        return request.post(url, data).then((res) => {
            return res.data as UserModel;
        });
    }

    public async create(model: CreateUserModel): Promise<CreateUserModel> {
        const url = `${this.ENDPOINT}/register`;
        // const url = `${this.ENDPOINT}/RegisterUser`;
        // const url = `/RegisterUser`;
        return request.post<CreateUserModel>(url, model).then((res) => {
            return res.data;
        });
    }
}
export default new AuthService();
