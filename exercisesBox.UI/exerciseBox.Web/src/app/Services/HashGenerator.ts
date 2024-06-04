import { Md5 } from "ts-md5";

export class HashGenerator {
    static generateHash(value : string) {
        return Md5.hashStr(value);
    }
}