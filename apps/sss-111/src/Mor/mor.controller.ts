import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as errors from "../errors";
import { MorService } from "./mor.service";
import { Muly } from "../mor/Muly";

@swagger.ApiTags("mors")
@common.Controller("mors")
export class MorController {
  constructor(protected readonly service: MorService) {}

  @common.Post("/:id/my-action")
  @swagger.ApiOkResponse({
    type: String
  })
  @swagger.ApiNotFoundResponse({
    type: errors.NotFoundException
  })
  @swagger.ApiForbiddenResponse({
    type: errors.ForbiddenException
  })
  async MyAction(
    @common.Param()
    params: string,
    @common.Query()
    query: string,
    @common.Body()
    body: Muly
  ): Promise<string> {
        const args = {
  prop2: params,
  prop3: query,
  prop1: body,
  };
  return this.service.MyAction(args);
      }

  @common.Get("/:id/my-other-action")
  @swagger.ApiOkResponse({
    type: String
  })
  @swagger.ApiNotFoundResponse({
    type: errors.NotFoundException
  })
  @swagger.ApiForbiddenResponse({
    type: errors.ForbiddenException
  })
  async MyOtherAction(
    @common.Body()
    body: Muly
  ): Promise<string> {
        return this.service.MyOtherAction(body);
      }
}
