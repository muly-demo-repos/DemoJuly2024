import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { SalespersonService } from "./salesperson.service";
import { SalespersonControllerBase } from "./base/salesperson.controller.base";

@swagger.ApiTags("salespeople")
@common.Controller("salespeople")
export class SalespersonController extends SalespersonControllerBase {
  constructor(
    protected readonly service: SalespersonService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
