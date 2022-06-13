# Personal E-Commerce Website Using Blazor Server

E-Commerce websites are online portals that facilitate online transactions of goods and services through means of the transfer of information and funds over the Internet.

I build this Ecommerce site using Blazor for both Front End and Back End. And, using PostgresSQL as data base.

User can go choose the product they want and add to the cart, if you want to remove the item, just click the x symbol in your cart. User doesn't have to login or register to buy product.But the cart of each individual user on each device is complete than other people, they will not have a random product of some one else in their cart. Because they don't have to login but still using individual account to separate they cart to other user. 

This Ecommerce also have a blog site included, therefore, owner can create blog post about their product or service. Use can comment on blog completely anonymous.

Last but not least, user can purchase the product simply by click on process to check out in the cart. I use Stripe API to handle the payment, and customer credit card to 100% safe by using Stripe API.

If you want to visit my ecommerce online market. You can click on this link to have a quick look at it:

http://duylanle-ecommerce.herokuapp.com/

Notes: Because my ecommerce is hosted on a free Heroku server. So, it will take a minute to boot up.

This application is working out of the box the first time you run it. I assume you already install **Postgres SQL** and .NET 6, also changed connection string password to match your local postgres. (please install **Postgres SQL**, **PG Admin**, and .NET 6 to run it without any issue).

You will use my Gmail EmailSender to send out email notification. Please search lanle97business@gmail.com and replace it with your smtp.google.com Email sender and your encryted password. You may need to register Google smtp in order to have those data.

Payment system is working. You can use Stripe Test Credit Card **4242 4242 4242 4242** with **any** date or code.

This application is a **Testing** app. Not for production. Even it's working out of the box but you may want to do a lot of customization to make it fit your needs.

Blazor Server may not a good choice for Ecommerce, but you can start learning Blazor through Blazor Server. 

I would say Blazor WASM is a better choice for Ecommerce.

