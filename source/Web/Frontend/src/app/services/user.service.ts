import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AppTokenService } from "../core/services/token.service";
import { SignInModel } from "../models/signIn.model";
import { TokenModel } from "../models/token.model";
import { AddUserModel } from "../models/user/add.user.model";
import { UpdateUserModel } from "../models/user/update.user.model";
import { UserModel } from "../models/user/user.model";

@Injectable({ providedIn: "root" })
export class AppUserService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
        private readonly appTokenService: AppTokenService) { }

    add(addUserModel: AddUserModel) {
        return this.http.post<number>(`Users`, addUserModel);
    }

    delete(id: number) {
        return this.http.delete(`Users/${id}`);
    }

    list() {
        return this.http.get<UserModel[]>(`Users`);
    }

    select(id: number) {
        return this.http.get<UserModel>(`Users/${id}`);
    }

    signIn(signInModel: SignInModel): void {
        this.http
            .post<TokenModel>(`Users/SignIn`, signInModel)
            .subscribe((tokenModel) => {
                if (!tokenModel || !tokenModel.token) { return; }
                this.appTokenService.set(tokenModel.token);
                this.router.navigate(["/main/home"]);
            });
    }

    signOut() {
        this.appTokenService.clear();
        this.router.navigate(["/login"]);
    }

    update(updateUserModel: UpdateUserModel) {
        return this.http.put(`Users/${updateUserModel.id}`, updateUserModel);
    }
}
