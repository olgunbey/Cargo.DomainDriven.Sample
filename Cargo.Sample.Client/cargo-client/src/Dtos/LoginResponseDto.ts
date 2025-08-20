

export interface LoginResponseDto {

    userId:string;
    accessToken:string;
    refreshToken:string;
    accessTokenLifeTime:Date;
    refreshTokenLifeTime:Date;

}