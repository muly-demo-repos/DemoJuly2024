import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as errors from "../errors";
import { MorService } from "./mor.service";
import { Muly } from "../mor/Muly";

@swagger.ApiTags("mors")
@common.Controller("mors")
export class MorController {
  constructor(protected readonly service: MorService) {}

  @common.Post("/muly")
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
    body: Muly
  ): Promise<string> {
        const args = {
  prop1: body,
  };
  return this.service.MyAction(args);
      }

  @common.Post("/muly")
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

  @common.Post("/applications")
  @swagger.ApiOkResponse({
    type: Muly
  })
  @swagger.ApiNotFoundResponse({
    type: errors.NotFoundException
  })
  @swagger.ApiForbiddenResponse({
    type: errors.ForbiddenException
  })
  async ThirdAction(
    @common.Body()
    body: Muly
  ): Promise<Muly> {
        return this.service.ThirdAction(body);
      }
}
