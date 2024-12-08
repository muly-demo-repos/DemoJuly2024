import * as graphql from "@nestjs/graphql";
import * as nestAccessControl from "nest-access-control";
import * as gqlACGuard from "../auth/gqlAC.guard";
import { GqlDefaultAuthGuard } from "../auth/gqlDefaultAuth.guard";
import * as common from "@nestjs/common";
import { SalespersonResolverBase } from "./base/salesperson.resolver.base";
import { Salesperson } from "./base/Salesperson";
import { SalespersonService } from "./salesperson.service";

@common.UseGuards(GqlDefaultAuthGuard, gqlACGuard.GqlACGuard)
@graphql.Resolver(() => Salesperson)
export class SalespersonResolver extends SalespersonResolverBase {
  constructor(
    protected readonly service: SalespersonService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
