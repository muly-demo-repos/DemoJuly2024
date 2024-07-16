import * as graphql from "@nestjs/graphql";
import { Muly } from "../mor/Muly";
import { MorService } from "./mor.service";

export class MorResolver {
  constructor(protected readonly service: MorService) {}

  @graphql.Query(() => String)
  async MyAction(
    @graphql.Args()
    args: Muly
  ): Promise<string> {
    return this.service.MyAction(args);
  }

  @graphql.Query(() => String)
  async MyOtherAction(
    @graphql.Args()
    args: string
  ): Promise<string> {
    return this.service.MyOtherAction(args);
  }

  @graphql.Query(() => Muly)
  async ThirdAction(
    @graphql.Args()
    args: Muly
  ): Promise<Muly> {
    return this.service.ThirdAction(args);
  }
}
