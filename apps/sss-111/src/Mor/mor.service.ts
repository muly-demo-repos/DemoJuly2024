import { Injectable } from "@nestjs/common";
import { Muly } from "../mor/Muly";

@Injectable()
export class MorService {
  constructor() {}
  async MyAction(args: Muly): Promise<string> {
    throw new Error("Not implemented");
  }
  async MyOtherAction(args: string): Promise<string> {
    throw new Error("Not implemented");
  }
}
