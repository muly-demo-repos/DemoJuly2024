import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { SaleModuleBase } from "./base/sale.module.base";
import { SaleService } from "./sale.service";
import { SaleController } from "./sale.controller";
import { SaleResolver } from "./sale.resolver";

@Module({
  imports: [SaleModuleBase, forwardRef(() => AuthModule)],
  controllers: [SaleController],
  providers: [SaleService, SaleResolver],
  exports: [SaleService],
})
export class SaleModule {}
