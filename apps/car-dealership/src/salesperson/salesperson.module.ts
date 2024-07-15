import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { SalespersonModuleBase } from "./base/salesperson.module.base";
import { SalespersonService } from "./salesperson.service";
import { SalespersonController } from "./salesperson.controller";
import { SalespersonResolver } from "./salesperson.resolver";

@Module({
  imports: [SalespersonModuleBase, forwardRef(() => AuthModule)],
  controllers: [SalespersonController],
  providers: [SalespersonService, SalespersonResolver],
  exports: [SalespersonService],
})
export class SalespersonModule {}
