import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as errors from "../errors";
import { MorService } from "./mor.service";

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
    @common.Body()
    body: string
  ): Promise<string> {
        const args = {
  prop1: body,
  };
  return this.service.MyAction(args);
      }
}
