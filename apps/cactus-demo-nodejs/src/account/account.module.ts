import { Module } from "@nestjs/common";
import { AccountModuleBase } from "./base/account.module.base";
import { AccountService } from "./account.service";
import { AccountController } from "./account.controller";

@Module({
  imports: [AccountModuleBase],
  controllers: [AccountController],
  providers: [AccountService],
  exports: [AccountService],
})
export class AccountModule {}
