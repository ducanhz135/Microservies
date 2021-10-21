# Microservies
------ K8S ---------
kubectl apply -f platforms-depl.yaml
kubectl get deployments
kubectl get pods
kubectl delete deployments {deployment-name}


kubectl apply -f platforms-np-srv.yaml
kubectl get services

--- Messaging +http Factory

docker build -t ducanhz135/commandservice .
docker run -p 8080:80 ducanhz135/commandservice
docker push ducanhz135/commandservice

---k8s -----
kubectl rollout restart deployment platforms-depl

--------api gateway----------------

ingress-nginx kubernetes
https://kubernetes.github.io/ingress-nginx/deploy/#docker-desktop

kubectl get namespace
kubectl get pods --namespace=ingress-nginx

---------K8S secret mssql------------
kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55w0rd!"

------deploy sql to k8s----------
kubect get pvc
kubectl get storageclass

mssql-plat-depl.yaml

------ accessing mssql server + update paltformService using mssql server----------
dotnet ef migrations add initialmigration
build image and push ducanhz135/platformservice 

restart deployment

-------- RabbitMQ ---------------
rabbitmq-depl.yaml
config appsetting
map object

using RabbitMQ.Client
---> publisher --- PublishNewPlatform()
---> subcriber


--------EventProcessor---------


-------- GRPC -------------------
proto file