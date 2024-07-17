import { Module } from "@nestjs/common";
import { TeamModuleBase } from "./base/team.module.base";
import { TeamService } from "./team.service";
import { TeamController } from "./team.controller";

@Module({
  imports: [TeamModuleBase],
  controllers: [TeamController],
  providers: [TeamService],
  exports: [TeamService],
})
export class TeamModule {}
