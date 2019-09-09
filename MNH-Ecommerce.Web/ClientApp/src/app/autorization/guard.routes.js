"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var GuardRoutes = /** @class */ (function () {
    function GuardRoutes() {
    }
    GuardRoutes.prototype.canActivate = function (route, state) {
        //se usuario autenticado
        return true;
    };
    return GuardRoutes;
}());
exports.GuardRoutes = GuardRoutes;
//# sourceMappingURL=guard.routes.js.map