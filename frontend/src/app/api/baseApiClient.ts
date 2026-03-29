import { inject } from "@angular/core";
import { ConfigurationService, NotificationService } from "../services";
import { Observable } from "rxjs";

export class BaseApiClient {
    private configurationService!: ConfigurationService;
    private notificationService!: NotificationService;
    
    constructor() {
        this.init();
    }

    protected getBaseUrl(baseUrl: string) : string {
        let url = this.configurationService.getApiBaseUrl();
        return url.replace(/\/$/, '');

    }


    protected transformResult(url: string, response: any, processor: (response: any) => Observable<any>): Observable<any> {
       this.handleError(response);

       return processor(response);
    }

    private handleError(response: any){
        if (response.status == 500) {
                this.notificationService.showError("Внутренняя ошибка сервера.");
        }
    }


    private init() {
        this.configurationService = new ConfigurationService();

        this.notificationService = inject(NotificationService); 
    }
}