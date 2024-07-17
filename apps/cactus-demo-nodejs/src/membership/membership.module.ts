import { Module } from "@nestjs/common";
import { MembershipModuleBase } from "./base/membership.module.base";
import { MembershipService } from "./membership.service";
import { MembershipController } from "./membership.controller";

@Module({
  imports: [MembershipModuleBase],
  controllers: [MembershipController],
  providers: [MembershipService],
  exports: [MembershipService],
})
export class MembershipModule {}
