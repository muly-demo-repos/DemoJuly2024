import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { YuvalService } from "./yuval.service";
import { YuvalControllerBase } from "./base/yuval.controller.base";

@swagger.ApiTags("yuvals")
@common.Controller("yuvals")
export class YuvalController extends YuvalControllerBase {
  constructor(
    protected readonly service: YuvalService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
