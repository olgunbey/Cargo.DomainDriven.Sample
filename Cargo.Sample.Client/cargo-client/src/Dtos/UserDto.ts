
export class UserDto {
    public userId: string
    public accessToken: string
    public refreshToken: string
    public refreshTokenLifeTime: Date
    public accessTokenLifeTime: Date


    constructor(userId: string, accessToken: string, refreshToken: string, refreshTokenLifeTime: Date, accessTokenLifeTime: Date) {
        this.userId = userId;
        this.accessToken = accessToken;
        this.refreshToken = refreshToken;
        this.refreshTokenLifeTime = refreshTokenLifeTime;
        this.accessTokenLifeTime = accessTokenLifeTime;
    }
}